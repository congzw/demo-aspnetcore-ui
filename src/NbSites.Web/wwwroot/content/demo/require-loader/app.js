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

//define("mainApp", ["vue", "ELEMENT", "httpVueLoader"], function (Vue, ele, httpVueLoader) {

//    Vue.use(ele);

//    var app = new Vue({
//        el: "#app",
//        components: {
//            'demo-timeline': httpVueLoader('./demo-timeline.vue')
//        }
//    });

//    return app;
//});
//require(["mainApp"], function (mainApp) {

//});

require(["vue", "ELEMENT", "httpVueLoader"], function (Vue, ele, httpVueLoader) {

    Vue.use(ele);

    var app = new Vue({
        el: "#app",
        components: {
            //'demo-timeline': httpVueLoader('./demo-timeline.vue')
        }
    });

    return app;
});

//define("mainApp", ["vue", "ELEMENT", "httpVueLoader"], function (Vue, ele, httpVueLoader) {

//    console.log('create vue mainApp');
//    //console.log(Vue);
//    //console.log(httpVueLoader);
//    //console.log(ele);
//    Vue.use(ele);

//    var app = new Vue({
//        el: "#app",
//        components: {
//            //'demo-timeline': httpVueLoader('./demo-timeline.vue')
//        }
//    });

//    return app;
//});



//require(["vue", "mainApp", "httpVueLoader"], function (Vue, mainApp, httpVueLoader) {


//    //var load = httpVueLoader('./demo-timeline.vue');
//    //load().then(function (res) {
//    //    console.log(res);
//    //    var theOne = Vue.extend(res);
//    //    theOne.$mount('#test');
//    //});

//    (async () => {

//        var res = await httpVueLoader('./demo-timeline.vue')();
//        var theOne = Vue.extend(res);
//        new theOne().$mount('#test');
//    })();


//});

//require(["vue", "ELEMENT", "httpVueLoader"], function (Vue, ele, httpVueLoader) {

//    //console.log(Vue);
//    //console.log(httpVueLoader);
//    //console.log(ele);
//    Vue.use(ele);

//    var app = new Vue({
//        el: "#app",
//        components: {
//            //'demo-timeline': httpVueLoader('./demo-timeline.vue')
//        }
//    });
//});

//require(["vue", "mainApp", "httpVueLoader"], function (Vue, mainApp, httpVueLoader) {
//    console.log('add component');
//    console.log(Vue);
//    console.log(mainApp);
//    //var load = httpVueLoader('./demo-timeline.vue').then(function (res) {
//    //    console.log();
//    //});
//    var load = httpVueLoader('./demo-timeline.vue');
//    console.log(load);
//    console.log(load().then(function (res) {
//        console.log(res);
//        var theOne = Vue.extend(res);
//        mainApp.$options.components['demo-timeline'] = theOne;
//    }));
//    //var Profile = Vue.extend(httpVueLoader('./demo-timeline.vue'));

//    //mainApp.$options.components['demo-timeline'] = Profile;
//});