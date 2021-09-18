<template>
  <div>
    <el-button type="primary" class="addbtn" @click="addMenu"
      >添加菜单</el-button
    >
    <el-button type="primary" class="addbtn" @click="test">测试</el-button>

    <el-dialog title="收货地址" :visible.sync="dialogFormVisible">
      <rbac-create ref="modelcreate"></rbac-create>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="save">确 定</el-button>
      </div>
    </el-dialog>

    <el-table :data="tableData" style="width: 100%" stripe border :key="timer">
      <el-table-column prop="menuID" label="菜单ID" sortable width="180">
      </el-table-column>
      <el-table-column prop="menuName" label="菜单名称" sortable width="180">
      </el-table-column>
      <el-table-column prop="menuLink" label="菜单链接" :formatter="format">
      </el-table-column>
      <el-table-column prop="createByName" label="创建人"> </el-table-column>
      <el-table-column prop="createTime" label="创建时间" sortable>
      </el-table-column>
    </el-table>
  </div>
</template>
<script>
import config from "../../utils/config";
import rbacCreate from "./create.vue";
import bus from "../../router/bus";

export default {
  name: "rootmenu",
  inject:['reload'],
  components: { rbacCreate },
  data() {
    return {
      timer: new Date().getTime(),
      key: 1,
      tableData: [],
      dialogFormVisible: false,
      formLabelWidth: "120px",
    };
  },
  methods: {
    format(row, col) {
      if (row.menuLink == undefined) return "-";
      else return row.menuLink;
    },
    addMenu() {
      this.dialogFormVisible = true;
    },
    save() {
      this.$refs.modelcreate.submitForm("ruleForm").then((o)=>{
        this.dialogFormVisible = false;        
      });
    },
    test() {
      this.reload();
    },
  },
  mounted() {
    config.axios.get("/sysmenu/rootmenu").then((m) => {
      this.tableData = m.data;
    });
    bus.$on("send", (o) => {
      this.dialogFormVisible = o;
      config.axios.get("/sysmenu/rootmenu").then((m) => {
        this.tableData = m.data;
      });
    });
  },
};
</script>

<style scoped>
.addbtn {
  margin-bottom: 12px;
}
</style>