requirejs.config({
    //urlArgs: "v=20200811",
    paths: {
        "vue": "/content/libs/vue/vue",
        "ELEMENT": "/content/libs/element-ui/index",
        "httpVueLoader": "/content/libs/vue/httpVueLoader"
    },
    shim: {
        "vue": { "exports": "Vue" },
        "ELEMENT": { "exports": "ELEMENT", "depends": "vue" },
        "httpVueLoader": { "exports": "httpVueLoader", "depends": "vue" }
    }
});

//require(["vue", "ELEMENT", "httpVueLoader"], function (Vue, ele, httpVueLoader) {

//    //全局注册
//    Vue.use(ele);
//    var app = new Vue({
//        el: "#app",
//        components: {
//            'demo-timeline': httpVueLoader('./demo-timeline.vue'),
//            'demo-complex': httpVueLoader('./demo-complex.vue')
//        }
//    });
//    return app;
//});

require(["vue", "ELEMENT", "httpVueLoader"], function (Vue, ele, httpVueLoader) {

    //全局注册
    Vue.use(ele);
    Vue.component('demo-timeline', httpVueLoader('./demo-timeline.vue'));
    Vue.component('demo-complex', httpVueLoader('./demo-complex.vue'));
    var app = new Vue({
        el: "#app"
    });
    return app;
});
