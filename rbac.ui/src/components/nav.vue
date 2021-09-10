<template>
  <el-breadcrumb separator-class="el-icon-arrow-right">
    <el-breadcrumb-item :to="{ path: '/' }">首页</el-breadcrumb-item>
    <template v-if="submenu.length > 0">
      <el-breadcrumb-item>
        {{ submenu }}
      </el-breadcrumb-item>
      <el-breadcrumb-item>
        {{ menuitem }}
      </el-breadcrumb-item>
    </template>
  </el-breadcrumb>
</template>

<script>
export default {
  data() {
    return {};
  },
  props: {
    submenu: {
      type: String,
    },
    menuitem: {
      type: String,
    },
  },
};
</script>