const htmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
   mode: 'development',
   entry: './src/index.js',
   output: {
      path: __dirname + '/public',
      filename: 'bundle.[hash].js',
      chunkFilename: '[id],js',
      publicPath: '/'
   },
   resolve: {
      extensions: ['.js', '.jsx']
   },
   module: {
      rules: [
         {
            test: /\.(js|jsx)$/,
            loader: 'babel-loader',
            exclude: /node_modules/,
         },
      ]
   },
   plugins: [
      new htmlWebpackPlugin({
         template: __dirname + '/public/index.html',
         filename: 'index.html',
         inject: 'body',
      }),
   ],
   devServer: {
      historyApiFallback: true
   },
}