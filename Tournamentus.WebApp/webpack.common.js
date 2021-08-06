const webpack = require('webpack');
const path = require('path');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

const assets = path.join(__dirname, 'wwwroot');
const glob = require('glob');

const entries = {
    'babel-polyfill': 'babel-polyfill',
    site: './Content/js/site',
};

const files = glob.sync('./Features/**/*.main.js');
files.forEach((file) => {
    const fileName = file.match('./Features/(.+/[^/]+).main.js')[1];
    const entryName = `${fileName}`;

    entries[entryName] = file;
});

module.exports = {
    entry: entries,
    output: {
        path: assets,
    },
    resolve: {
        alias: {
            easyCubeComponents: path.resolve('./Content/js'),
        },
        extensions: ['.js'],
        modules: ['./node_modules'],
    },
    optimization: {
        splitChunks: {
            cacheGroups: {
                commons: {
                    name: "commons",
                    chunks: "initial",
                    minChunks: 2
                }
            }
        },
    },
    module: {
        rules: [
            { test: /\.js?$/, exclude: /node_modules/, loaders: ['babel-loader'] },
            {
                test: /\.(jpe?g|png|gif)$/,
                loader: 'file-loader',
                options: {
                    name: '[name].[ext]',
                    useRelativePath: true,
                },
            },
            {
                test: /\.(eot|svg|ttf|otf|woff|woff2)$/,
                loader: 'file-loader',
                options: {
                    name: '[name].[ext]',
                    useRelativePath: true,
                },
            },
        ],
    },
    plugins: [
        new webpack.ProvidePlugin({
            jQuery: 'jquery',
            $: 'jquery',
        }),
    ],
};
