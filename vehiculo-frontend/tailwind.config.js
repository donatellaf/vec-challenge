const defaultTheme = require("tailwindcss/defaultTheme");

module.exports = {
  content: ["./src/**/*.{js,jsx,ts,tsx}"],
  theme: {
    // fontFamily: {
    //   sans: ['"PT Sans"', "sans-serif"],
    // },
    // extend: {
    //   colors: {
    //     primary: "#363636",
    //     secondary: "#EFEFEF",
    //     white: "#FFFFFF",
    //     "button-hover": "#F7F7F7",
    //     gray: "#767676",
    //     title: "#6F6F6F",
    //   },
    // },
  },
  plugins: [
    require("@tailwindcss/forms"),
    require("@tailwindcss/aspect-ratio"),
  ],
};
