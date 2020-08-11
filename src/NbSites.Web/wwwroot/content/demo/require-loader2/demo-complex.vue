<template>
    <div class="block">
        <h2>Complex DEMO</h2>
        <hr />
        <demo-timeline foo="Hello"></demo-timeline>
    </div>
</template>
<style>
</style>
<script>
    module.exports = {
        //全局注册的组件，组件内部将不用再次引用
        //components: {
        //    'demo-timeline': httpVueLoader('./demo-timeline.vue')
        //},
        data() {
            return {
                foo: 'foo'
            };
        }
    };
</script>