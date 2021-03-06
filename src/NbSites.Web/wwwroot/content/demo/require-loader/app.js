﻿requirejs.config({
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

    ////demo for global register
    //Vue.component('demo-timeline', httpVueLoader('./demo-timeline.vue'));
    //var app = new Vue({
    //    el: "#app"
    //});
    
    //demo for separate register
    var app = new Vue({
        el: "#app",
        components: {
            'demo-timeline': httpVueLoader('./demo-timeline.vue')
        }
    });

    return app;
});