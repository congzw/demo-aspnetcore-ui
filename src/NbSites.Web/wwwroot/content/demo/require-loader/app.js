requirejs.config({
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

    //console.log(Vue);
    //console.log(httpVueLoader);
    //console.log(ele);
    Vue.use(ele);
    
    var app = new Vue({
        el: "#app",
        components: {
            'demo-timeline': httpVueLoader('./demo-timeline.vue')
        }
    });
});