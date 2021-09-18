<template>
  <div>
    <el-button type="primary" class="addbtn" @click="addMenu" size="medium"
      >添加菜单</el-button
    >
    <el-button type="danger" size="medium" @click="BulkDelete"
      >批量删除</el-button
    >

    <el-dialog title="收货地址" :visible.sync="dialogFormVisible">
      <component :is="formName" ref="menuForm"></component>
      <div slot="footer" class="dialog-footer">
        <el-button @click="dialogFormVisible = false">取 消</el-button>
        <el-button type="primary" @click="save">确 定</el-button>
      </div>
    </el-dialog>

    <el-table
      :data="tableData"
      style="width: 100%"
      stripe
      border
      :key="timer"
      @selection-change="handleSelectionChange"
    >
      <el-table-column type="selection" sortable> </el-table-column>
      <el-table-column prop="menuID" label="菜单ID" sortable width="180">
      </el-table-column>
      <el-table-column
        prop="menuName"
        label="菜单名称"
        :formatter="formatName"
        sortable
        width="180"
      >
      </el-table-column>
      <el-table-column prop="menuLink" label="菜单链接" :formatter="format">
      </el-table-column>
      <el-table-column prop="createByName" label="创建人"> </el-table-column>
      <el-table-column prop="createTime" label="创建时间" sortable>
      </el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button
            size="mini"
            @click="handleEdit(scope.$index, scope.row, scope.column)"
            >编辑</el-button
          >
          <el-button
            size="mini"
            type="danger"
            @click="handleDelete(scope.$index, scope.row)"
            >删除</el-button
          >
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>
<script>
import config from "../../utils/config";
import menuCreate from "./create.vue";
import menuEdit from "./edit.vue";
import bus from "../../router/bus";

export default {
  name: "rootmenu",
  inject: ["reload"],
  components: {
    menuCreate,
    menuEdit,
  },
  data() {
    return {
      formName: "menuCreate",
      timer: new Date().getTime(),
      key: 1,
      tableData: [],
      dialogFormVisible: false,
      formLabelWidth: "120px",
      multipleSelection: [],
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
      this.$refs.menuForm.submitForm("ruleForm").then((o) => {
        this.dialogFormVisible = false;
        config.axios.get("/sysmenu/rootmenu").then((m) => {
          this.tableData = m.data;
        });
      });
    },
    handleSelectionChange(val) {
      this.multipleSelection = val;
    },
    formatName(row, column, cellValue, index) {
      return cellValue;
    },
    handleEdit(index, row, col) {
      this.dialogFormVisible = true;
      this.formName = "menuEdit";
      this.$nextTick(() => {
        this.$refs.menuForm.getmenu(row.menuID);
      });
    },
    BulkDelete() {
      if (this.multipleSelection.length == 0) {
        this.$message({
          message: "请至少选择一条数据",
          type: "warning",
        });
        return;
      }
      this.$confirm("此操作将永久删除该文件, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          //此处编写批量删除代码


          this.$message({
            type: "success",
            message: "删除成功!",
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除",
          });
        });
    },
    handleDelete(index, row) {
      this.$confirm("此操作将永久删除该文件, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          config.axios
            .get("/sysmenu/Delete/", {
              params: {
                id: row.menuID,
              },
            })
            .then((o) => {
              this.tableData = this.tableData.filter(
                (m) => m.menuID != row.menuID
              );
              this.$message({
                type: "success",
                message: "删除成功!",
              });
            });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除",
          });
        });
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