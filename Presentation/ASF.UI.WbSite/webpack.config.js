var path = require('path');
var webpack = require('webpack');
var ExtractTextPlugin = require("extract-text-webpack-plugin");



module.exports = {
    context: __dirname,
    entry: './AngularControllers/Principal.js',
    output: {
        path: path.join(__dirname, 'Built'),
        filename: '[name].bundle.js'
    },
    watch: true,
    resolve: { modules: ["node_modules"] },
    module: {
        
        //loaders: [
        //    {
        //        //test: /\.css$/,
        //        include: [
        //            path.resolve(__dirname, "not_exist_path")
        //        ],
        //        test: /\.css$/,
        //        loader: 'style-loader!css-loader'
        //    },
        //    {
        //        test: /\.(png|jpg|woff|woff2|eot|ttf|svg)(\?v=[0-9]\.[0-9]\.[0-9])?$/,
        //        loader: 'url?limit=512&&name=[path][name].[ext]?[hash]'
        //    },
        //    //{
        //    //    test: /\.css$/,
        //    //    loader: 'style-loader!css-loader'
        //    //},
        //    //{
        //    //    test: /\.(eot|svg|ttf|woff|woff2)(\?\S*)?$/,
        //    //    loader: 'file-loader'
        //    //},
        //    //{
        //    //    test: /\.css$/,
        //    //    include: [
        //    //        path.resolve(__dirname, "not_exist_path")
        //    //    ],
        //    //    loaders: ['style-loader', 'css-loader']
        //    //},
        //],

        rules: [
            {
                test: /\.css$/,
                use: [
                    { loader: 'style-loader' },
                    {
                        loader: 'css-loader',
                        options: {
                            modules: true
                        }
                    }
                ]
            },
            {
                test: /\.(eot|woff|woff2|ttf|svg|png|jpg)$/,
                loader: 'url-loader?limit=30000&name=[name]-[hash].[ext]'
                },
        ]



    },
    plugins: [
        new ExtractTextPlugin("[name].css")
    ]
    //plugins: [
    //    // Output extracted CSS to a file
    //    new ExtractTextPlugin('[name].[chunkhash].css')
    //]
    //plugins: [new ExtractTextPlugin("app.css")]
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
