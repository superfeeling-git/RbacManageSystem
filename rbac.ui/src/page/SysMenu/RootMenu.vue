<template>
  <div>
    <el-table :data="tableData" style="width: 100%" stripe border>
      <el-table-column prop="menuID" label="菜单ID" sortable width="180"> </el-table-column>
      <el-table-column prop="menuName" label="菜单名称" sortable width="180"> </el-table-column>
      <el-table-column prop="menuLink" label="菜单链接" :formatter="format"> </el-table-column>
      <el-table-column prop="createByName" label="创建人"> </el-table-column>
      <el-table-column prop="createTime" label="创建时间" sortable> </el-table-column>
    </el-table>
  </div>
</template>
<script>
import config from "../../utils/config";

export default {
    data() {
        return {
            tableData:[]
        }
    },
    methods: {
        format(row,col){
            console.log(col);
            if(row.menuLink == undefined)
                return '-';
            else
                return row.menuLink;
        }
    },
    mounted() {
        config.axios.get("/sysmenu/rootmenu").then((m) => {
            this.tableData = m.data;
        });
    },
};
</script>