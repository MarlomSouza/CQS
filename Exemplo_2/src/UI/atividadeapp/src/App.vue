<template>
  <div class="container-fluid">
    <router-view />
  </div>
</template>

<script>
export default {
}
</script>

<style lang="scss">
@import "../node_modules/bootstrap/scss/bootstrap.scss";
.ponteiro {
  cursor: pointer;
}
.service-form {
  background-color: #fafbfb;
  border: 1px solid #e4e8ea;
  padding: 40px 40px 20px 40px;
}

#nprogress .bar {
  height: 5px;
}
#nprogress .spinner-icon {
  width: 20px;
  height: 20px;

  border: solid 5px transparent;
  border-top-color: #29d;
  border-left-color: #29d;
  border-radius: 50%;
}
</style>
