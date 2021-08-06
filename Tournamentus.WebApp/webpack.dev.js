const webpack = require('webpack');
const merge = require('webpack-merge');
const common = require('./webpack.common.js');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const StyleLintPlugin = require('stylelint-webpack-plugin');
const webpackPostcssTools = require('webpack-postcss-tools');

const variables = './Content/css/theme-map.css';
const theme = webpackPostcssTools.makeVarMap(variables);

module.exports = merge(common, {
    mode: 'development',
    output: {
        filename: 'js/[name].bundle.js',
    },
    devtool: 'inline-source-map',
    plugins: [
        new ExtractTextPlugin('css/main.css'),
        new StyleLintPlugin({ files: 'Content/css/**/*.css' }),
        new webpack.DefinePlugin({ 'process.env.NODE_ENV': JSON.stringify('development') }),
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
                    fix: true,
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
