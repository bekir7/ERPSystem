const HtmlWebPackPlugin = require("html-webpack-plugin");
const ModuleFederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");
const { VueLoaderPlugin } = require("vue-loader");
const path = require('path');
const webpack = require("webpack");

module.exports = (env, argv) => {
  return {
    optimization: {
      minimize: false,
    },
  output: {
    publicPath: "http://localhost:7081/",
  },
  resolve: {
    modules: [
      path.join(__dirname, 'node_modules')
  ],
    extensions: [ ".ts", ".vue", ".js", ".json",".scss"],
    alias: {
      '@': path.resolve(__dirname, 'src')

    }
  },
  performance: {
    hints: false,
    maxEntrypointSize: 512000,
    maxAssetSize: 512000,
  },
  devServer: {
    port: 7081,
    open: true,
    historyApiFallback: true,
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: "vue-loader",
      },
      {
        test: /\.tsx?$/,
        use: [
          'vue-style-loader',
          'css-loader',
          'sass-loader',
          "babel-loader",
          {
            loader: "ts-loader",
            options: {
              transpileOnly: true,
              appendTsSuffixTo: ["\\.vue$"],
              happyPackMode: true,
            },
          },
        ],
      },
  
      {
      test: /\.(jpg|JPG|PNG|png|jpe?g|gif|svg|SVG|woff|woff2|tff|eot)$/i,
      use: [
        {
          loader: 'file-loader',
        },
      ],
    },
      {
        test: /\.(css|s[ac]ss)$/i,
        use: [
          {
            loader: 'style-loader'
          },
          {
            loader: 'css-loader'
          },
          {
            loader: 'sass-loader'
          }
        ]                                                                                                                           
      },  
    
    ],
    
  },
  plugins: [
    new webpack.DefinePlugin({
      "process.env": JSON.stringify(require(`./env/env_${env.env}.json`)),
    }),
    new VueLoaderPlugin(),
    new ModuleFederationPlugin({
      name: "kurumsal_body",
      filename: "remoteEntry.js",
      remotes: {
      },
      exposes: {
        "./Layout": "./src/layouts/main.vue",
        "./PageHeader": "./src/components/page-header.vue",
      },
      shared: require("./package.json").dependencies,
    }),
    new HtmlWebPackPlugin({
      template: "./public/index.html",
    }),
  ],
}
};
