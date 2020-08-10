requirejs.config({
    paths: {
        "vue": "/content/libs/vue/vue",
        "ELEMENT": "/content/libs/element-ui/index"
    },
    shim: {
        "vue": { "exports": "Vue" },
        "ELEMENT": { "exports": "ELEMENT", "depends": "vue" }
    }
});

require(["vue", "ELEMENT"], function (Vue, ele) {

    //console.log(ele);

    //注意几个坑：
    //由于element-ui 内部写的 define("ELEMENT",["vue"],xxx)
    //所以它的别名必须叫ELEMENT 也必须有一个叫vue的依赖才能加载

    //1: vue的名称及其大小写
    //2：ELEMENT的名称及其大小写
    //3：Vue.use(ele);

    Vue.use(ele);
    var app = new Vue({
        el: "#app"
    });
});