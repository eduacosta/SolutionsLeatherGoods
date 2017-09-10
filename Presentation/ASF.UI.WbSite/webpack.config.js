var path = require('path');
var webpack = require('webpack');
var ExtractTextPlugin = require("extract-text-webpack-plugin");

var stylePathResolves = (
    'includePaths[]=' +
        path.resolve('./') +
        '&' +
        'includePaths[]=' +
        path.resolve('./node_modules')
);


module.exports = {
    context: __dirname ,
    entry: './AngularControllers/Principal.js',
    output: {
        path: path.join(__dirname, 'Built'),
        filename: '[name].bundle.js'
    },
    watch: true,
    module: {
        loaders: [{
            test: /\.jsx?$/,
            exclude: /node_modules/,
            loader: 'babel-loader'
        }, {
            test: /\.scss$/,
            loader: ExtractTextPlugin.extract(
                'style',
                'css' + '!sass?outputStyle=expanded&' + stylePathResolves
            )
        }, {
            test: /\.css$/,
            loader: "style-loader!css-loader"
        }, {
            test: /\.(png|jpg|jpeg|gif|svg|woff|woff2|ttf|eot)$/,
            loader: 'file-loader'
        }]
    },
    plugins: [new ExtractTextPlugin("app.css")]
    //module: {
    //    loaders: [
    //        // Extract css files
    //        {
    //            test: /\.css$/,
    //            loader: ExtractTextPlugin.extract("style-loader", "css-loader")
    //        },
    //        // Optionally extract less files
    //        // or any other compile-to-css language
    //        {
    //            test: /\.less$/,
    //            loader: ExtractTextPlugin.extract("style-loader", "css-loader!less-loader")
    //        }
    //        // You could also use other loaders the same way. I. e. the autoprefixer-loader
    //    ]
    //},
    //// Use the plugin to specify the resulting filename (and add needed behavior to the compiler)
    //plugins: [
    //    new ExtractTextPlugin("[name].css")
    //]
   
};
