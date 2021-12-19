const htmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
   mode: 'development',
   entry: './src/index.tsx',
   output: {
      path: __dirname + '/dist',
      filename: 'bundle.[hash].js',
      chunkFilename: '[id],js',
      publicPath: '/'
   },
   resolve: {
      extensions: ['.js', '.ts', '.tsx']
   },
   module: {
      rules: [
         {
            test: /\.(js|ts)x?$/,
            loader: 'babel-loader',
            exclude: /node_modules/,
         },
         {
            test: /\.css$/,
            use: [
               "style-loader",
               { loader: "css-loader", options: { importLoaders: 1 } },
               "postcss-loader",
            ],
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
