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

require(["vue", "ELEMENT", "httpVueLoader"], function (Vue, ele, httpVueLoader) {

    Vue.use(ele);

    //全局注册
    Vue.component('demo-timeline', httpVueLoader('./demo-timeline.vue'));
    Vue.component('demo-complex', httpVueLoader('./demo-complex.vue'));
    var app = new Vue({
        el: "#app"
    });
    
    //局部注册，无法满足子组件的嵌套！
    //var app = new Vue({
    //    el: "#app",
    //    components: {
    //        'demo-timeline': httpVueLoader('./demo-timeline.vue'),
    //        'demo-complex': httpVueLoader('./demo-complex.vue')
    //    }
    //});

    return app;
});
