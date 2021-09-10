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
            :unique-opened="true"
            ref="aside_nav"
          >
            <el-submenu index="1">
              <template slot="title">
                <i class="el-icon-location"></i>
                <span>权限设置</span>
              </template>
              <el-menu-item index="1-1" @click="openMenu('权限设置','管理员添加')">管理员添加</el-menu-item>
              <el-menu-item index="1-2" @click="openMenu('权限设置','管理员管理')">管理员管理</el-menu-item>
              <el-menu-item index="1-3" @click="openMenu('权限设置','菜单添加')">菜单添加</el-menu-item>
              <el-menu-item index="1-4" @click="openMenu('权限设置','菜单管理')">菜单管理</el-menu-item>
            </el-submenu>
            <el-submenu index="2">
              <template slot="title">
                <i class="el-icon-location"></i>
                <span>商品管理</span>
              </template>
              <el-menu-item index="2-1" @click="openMenu('商品管理','商品添加')">商品添加</el-menu-item>
            </el-submenu>
          </el-menu>
        </el-aside>
        <el-main>
          <nav-header :submenu="navData.submenu" :menuitem="navData.menuitem"></nav-header>
          <div class="main">
            <router-view></router-view>
          </div>
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script>
import navHeader from '../components/nav.vue'
export default {
  components:{
    navHeader
  },
  data() {
    return {
      navData:{
        submenu:"",
        menuitem:""
      }
    };
  },
  methods: {
    openMenu(submenu,menuitem){
      this.navData.submenu = submenu;
      this.navData.menuitem = menuitem;
      this.$router.push('/sysmenu/create');
    },
    logout() {
      this.$router.push("/");
    },
  },
  mounted() {
    //通过$refs实现组件的方法调用
    this.$refs.aside_nav.open(1);
    //通过$refs实现组件的属性赋值
    //对于中横杠的属性，可以采用驼峰命令引用属性，如unique-opened
    //this.$refs.aside_nav.uniqueOpened = true
  },
};
</script>

<style>
.ruleForm{
    width: 80%;
}
</style>

<style scoped>
.main {
  border-top: 1px solid #e2e2e2;
  margin-top: 20px;
  padding-top: 20px;
}
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
  color: #333;
  height: calc(100vh - 60px);
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