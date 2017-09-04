﻿var path = require('path');
//var webpack = require('webpack');

module.exports = {
    context: __dirname,
    entry: './AngularControllers/Principal.js',
    output: {
        path: path.join(__dirname, 'Built'),
        filename: '[name].bundle.js'
    },
    //plugins: [
    //    new webpack.optimize.CommonsChunkPlugin({ name: 'vendor', filename: 'vendor.bundle.js', minChunks: Infinity })
    //],
    //externals: {
    //    'angular': 'angular'
    //}
    //plugins: [
    //    new webpack.ProvidePlugin({
    //        'angular': 'angular'
    //    })
    //]
};
