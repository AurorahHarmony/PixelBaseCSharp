const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

const devMode = process.env.NODE_ENV !== "production";
module.exports = {
  mode: devMode ? "development" : "production",
  entry: ["./node_modules/bootstrap/dist/js/bootstrap.bundle.js", "./wwwroot/scss/theme.scss"],
  output: {
    path: path.resolve(__dirname, "wwwroot"),
    publicPath: "/css",
    filename: "js/bundle.js"
  },
  module: {
    rules: [
      {
        test: /\.(sa|sc)ss$/,
        use: [
          MiniCssExtractPlugin.loader,
          'css-loader',
          {
            loader: 'postcss-loader', // Run postcss actions
            options: {
              postcssOptions: {
                plugins: function () { // postcss plugins, can be exported to postcss.config.js

                  let plugins = [require('autoprefixer')];

                  if (argv.mode === "production") {

                    plugins.push(require('cssnano'));
                  }

                  return plugins;
                }
              }
            }
          },
          'sass-loader',
        ],
      }
    ]
  },
  plugins: [
    new MiniCssExtractPlugin({
      filename: devMode ? 'css/theme.css' : 'css/theme.min.css'
    })
  ]


}