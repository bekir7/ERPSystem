const HtmlWebPackPlugin = require("html-webpack-plugin");
const ModuleFederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");
const { VueLoaderPlugin } = require("vue-loader");
const path = require("path");
const webpack = require("webpack");

module.exports = (env, argv) => {
  return {
    optimization: {
      minimize: false,
    },
    output: {
      publicPath: "http://localhost:7082/",
    },
    resolve: {
      modules: [path.join(__dirname, "node_modules")],
      extensions: [".ts", ".vue", ".js", ".json", ".scss"],
      alias: {
        "@": path.resolve("src"),
      },
    },
    performance: {
      hints: false,
      maxEntrypointSize: 512000,
      maxAssetSize: 512000,
    },
    devServer: {
      port: 7082,
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
          test: /\.(jpg|JPG|PNG|png|jpe?g|gif|svg|woff|woff2|tff|eot)$/i,
          use: [
            {
              loader: "file-loader",
            },
          ],
        },
        {
          test: /\.(css|s[ac]ss)$/i,
          use: [
            {
              loader: "style-loader",
            },
            {
              loader: "css-loader",
            },
            {
              loader: "sass-loader",
            },
          ],
        },
      ],
    },
    plugins: [
      new webpack.DefinePlugin({
        "process.env": JSON.stringify(require(`./env/env_${env.env}.json`)),
      }),
      new VueLoaderPlugin(),
      new ModuleFederationPlugin({
        name: "kurumsal_btandrnd",
        filename: "remoteEntry.js",
        remotes: {
          kurumsalbody: "kurumsal_body@http://localhost:7081/remoteEntry.js",
        },
        exposes: {
          "./FaultManagement":
            "./src/views/btandrnd/information-technologies-rd/service-management/fault-management/fault-management.vue",
          "./Compatilibity":
            "./src/views/btandrnd/information-technologies-rd/service-management/compatilibity/compatilibity.vue",
          "./DataBase":
            "./src/views/btandrnd/information-technologies-rd/service-management/data-base/data-base.vue",
          "./InventoryManagement":
            "./src/views/btandrnd/information-technologies-rd/service-management/inventory-management/inventory-management.vue",
          "./RiskManagement":
            "./src/views/btandrnd/information-technologies-rd/service-management/risk-management/risk-management.vue",
            "./AdminPanel":
            "./src/views/btandrnd/information-technologies-rd/service-management/admin-panel/admin-panel.vue",
          "/ProjectManagement":
            "./src/views/btandrnd/information-technologies-rd/project-management/project-management.vue",
          "./ChangeManagement":
            "./src/views/btandrnd/information-technologies-rd/kvkk-processes/change-management/change-management.vue",
            "./ITSystemAccessProcess":
            "./src/views/btandrnd/information-technologies-rd/kvkk-processes/it-system-access-process/it-system-access-process.vue",
            "./BuyRequest":
            "./src/views/btandrnd/buy-systems/buy-process/buy-request/buy-request.vue",
        },
        shared: require("./package.json").dependencies,
      }),
      new HtmlWebPackPlugin({
        template: "./public/index.html",
      }),
    ],
  };
};
