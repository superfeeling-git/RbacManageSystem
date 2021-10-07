<template>
    <div>
        <el-button type="primary" class="addbtn" @click="addMenu" size="medium"
            >添加菜单</el-button
        >
        <el-dialog :title="dialogTitle" :visible.sync="dialogFormVisible">
            <component
                :is="formName"
                ref="menuForm"
                :pid="menuId"
                :key="new Date().getTime()"
            ></component>
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
            row-key="menuId"
            :default-expand-all="true"
        >
            <el-table-column prop="menuId" label="菜单ID" sortable width="120">
            </el-table-column>
            <el-table-column
                prop="menuName"
                label="菜单名称"
                sortable
                width="160"
            >
            </el-table-column>
            <el-table-column
                prop="menuLink"
                label="菜单链接"
                :formatter="format"
            >
            </el-table-column>
            <el-table-column
                prop="isShow"
                label="是否显示"
                :formatter="formatShow"
            >
            </el-table-column>
            <el-table-column prop="createByName" label="创建人" width="120">
            </el-table-column>
            <el-table-column
                prop="createTime"
                label="创建时间"
                sortable
                width="190"
            >
            </el-table-column>
            <el-table-column label="操作" width="280">
                <template slot-scope="scope">
                    <el-button
                        size="mini"
                        type="primary"
                        @click="
                            addSubMenu(scope.$index, scope.row, scope.column)
                        "
                        >添加子菜单</el-button
                    >
                    <el-button
                        size="mini"
                        type="success"
                        @click="
                            handleEdit(scope.$index, scope.row, scope.column)
                        "
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
import axios from "../../utils/axios";
import menuCreate from "../../page/SysMenu/create.vue";
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
            dialogTitle:"添加分类",
            menuId: 0,
            formName: "menuCreate",
            timer: new Date().getTime(),
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
        formatShow(row, col) {
            return row.isShow ? "显示" : "隐藏";
        },
        addSubMenu(index, row, col) {
            axios(`/SysMenu/GetPath?id=${row.menuId}`).then((res) => {
                this.formName = "menuCreate";
                this.dialogFormVisible = true;
                this.menuId = res.data;
            });
        },
        addMenu() {
            this.formName = "menuCreate";
            this.dialogFormVisible = true;
            this.menuId = [];
        },
        save() {
            this.$refs.menuForm.submitForm("ruleForm").then((o) => {
                this.dialogFormVisible = false;
                this.fetch();
            });
        },
        handleEdit(index, row, col) {
            this.dialogTitle="编辑分类";
            axios(`/SysMenu/GetPath?id=${row.menuId}`).then((res) => {
                this.formName = "menuEdit";
                this.dialogFormVisible = true;
                res.data.pop();
                this.menuId = res.data;
                this.$nextTick(() => {
                    this.$refs.menuForm.getmenu(row.menuId);
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
                    axios(`/sysmenu/Delete?id=${row.menuId}`).then((o) => {
                        if (o.data.code > 0) {
                            this.$message({
                                type: "warning",
                                message: o.data.msg,
                            });
                        } else {
                            this.tableData = this.tableData.filter(
                                (m) => m.menuId != row.menuId
                            );
                            this.$message({
                                type: "success",
                                message: "删除成功!",
                            });
                        }
                    });
                })
                .catch(() => {
                    this.$message({
                        type: "info",
                        message: "已取消删除",
                    });
                });
        },
        fetch() {
            axios("/sysmenu/GetMenu").then((m) => {
                this.tableData = m.data;
            });
        },
    },
    mounted() {
        this.fetch();
        bus.$on("send", (o) => {
            this.dialogFormVisible = o;
            this.fetch();
        });
    },
};
</script>