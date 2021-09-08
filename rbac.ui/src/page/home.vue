<template>
  <div>
    <el-container>
      <el-header>
        <el-row>
          <el-col :span="6" class="headText"> RBAC权限管理 </el-col>
          <el-col :span="6" :offset="12">
            <el-button icon="el-icon-male" size="small" circle></el-button>
            <el-button icon="el-icon-help" size="small" circle></el-button>
            <el-button icon="el-icon-upload" size="small" circle></el-button>
          </el-col>
        </el-row>
      </el-header>
      <el-container>
        <el-aside width="200px">
          <el-menu
            default-active="2"
            background-color="#06618f"
            text-color="#fff"
            active-text-color="#ffd04b"
          >
            <el-submenu index="1">
              <template slot="title">
                <i class="el-icon-location"></i>
                <span>导航一</span>
              </template>
              <el-menu-item index="1-1">选项1</el-menu-item>
              <el-menu-item index="1-2">选项2</el-menu-item>
            </el-submenu>
            <el-menu-item index="2">
              <i class="el-icon-menu"></i>
              <span slot="title">导航二</span>
            </el-menu-item>
            <el-menu-item index="3" disabled>
              <i class="el-icon-document"></i>
              <span slot="title">导航三</span>
            </el-menu-item>
            <el-menu-item index="4">
              <i class="el-icon-setting"></i>
              <span slot="title">导航四</span>
            </el-menu-item>
          </el-menu>
        </el-aside>
        <el-main>Main</el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script>
export default {
  data() {
    return {};
  },
  methods: {
    logout() {
      this.$router.push("/");
    },
  },
};
</script>

<style scoped>
.headText {
  text-align: left;
  font-size: 18px;
  font-weight: bold;
}
.el-header {
  background-color: #06618f;
  color: rgb(255, 255, 255);
  text-align: center;
  line-height: 60px;
}

.el-aside {
  background-color: #06618f;
  color: rgb(255, 255, 255);
  text-align: center;
  line-height: 200px;
  min-height: 100%;
}

.el-main {
  background-color: #e9eef3;
  color: #333;
  text-align: center;
  line-height: 160px;
  height: calc(100vh - 66px);
}

body > .el-container {
  margin-bottom: 40px;
}
.el-menu {
  border-right: none;
}
.el-submenu,
.el-menu-item {
  text-align: left;
}
</style>