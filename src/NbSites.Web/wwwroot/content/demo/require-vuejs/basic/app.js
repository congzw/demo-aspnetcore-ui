requirejs.config({
    paths: {
        "Vue": "/content/libs/vue/vue",
        "vue": "/content/libs/require/require-vuejs"
    },
    shim: {
        "Vue": { "exports": "Vue" }
    }
});

require(["Vue", "vue!component", "vue!component2.html"], function (Vue) {
    var app = new Vue({
        el: "#app"
    });
});