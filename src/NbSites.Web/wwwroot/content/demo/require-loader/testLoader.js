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

    Vue.use(ele);

    //todo: load from config or init
    var registry = [{ id: "demo-timeline", url: "./demo-timeline.vue" }];
    registry.forEach(function (c) {
        //register as global like ELEMENT, to support complex scenario e.g. nested components 
        Vue.component(c.id, httpVueLoader(c.url));
    });

    var app = new Vue({
        el: "#app"
    });
    
    //console.log(app.$options.components);
    return app;
});