const webpack = require('webpack');
const merge = require('webpack-merge');
const common = require('./webpack.common.js');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const StyleLintPlugin = require('stylelint-webpack-plugin');
const webpackPostcssTools = require('webpack-postcss-tools');
const CompressionPlugin = require('compression-webpack-plugin');

const variables = './Content/css/theme-map.css';
const theme = webpackPostcssTools.makeVarMap(variables);

module.exports = merge(common, {
    mode: 'production',
    output: {
        filename: 'js/[name].bundle.min.js',
    },
    plugins: [
        new ExtractTextPlugin('css/main.min.css'),
        new StyleLintPlugin({ files: 'Content/**/*.css' }),
        new webpack.DefinePlugin({ 'process.env.NODE_ENV': JSON.stringify('production') }),
        new CompressionPlugin({
            asset: "[path].gz[query]",
            algorithm: "gzip",
            test: /\.js$/,
            // threshold: 10240,
            minRatio: 0.8
        }),
    ],
    module: {
        rules: [
            {
                enforce: 'pre',
                test: /\.js$/,
                exclude: /node_modules/,
                loader: 'eslint-loader',
                options: {
                    emitError: true,
                    emitWarning: true,
                    // failOnError: true
                },
            },
            {
                test: /\.css$/,
                use: ExtractTextPlugin.extract({
                    publicPath: '../',
                    fallback: 'style-loader',
                    use: [
                        {
                            loader: 'css-loader',
                            options: {
                                importLoaders: 1,
                            },
                        },
                        {
                            loader: 'postcss-loader',
                            options: {
                                plugins() {
                                    return [
                                        require('postcss-import'),
                                        require('postcss-cssnext')({
                                            features: {
                                                customProperties: {
                                                    variables: theme.vars,
                                                },
                                                customMedia: {
                                                    extensions: theme.media,
                                                },
                                                customSelector: {
                                                    extensions: theme.selector,
                                                },
                                            },
                                        }),
                                        require('postcss-normalize'),
                                        require('cssnano')({
                                            preset: 'default',
                                        }),
                                    ];
                                },
                            },
                        },
                    ],
                }),
            },
        ],
    },
});
