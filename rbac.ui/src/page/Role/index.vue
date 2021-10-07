<template>
    <div>
        <el-button type="primary" class="addbtn" @click="addRole" size="medium"
            >添加角色</el-button
        >
        <el-table :data="tableData" stripe style="width: 100%" border>
            <el-table-column prop="roleId" label="ID"> </el-table-column>
            <el-table-column prop="roleName" label="角色名称">
            </el-table-column>
            <el-table-column prop="createByName" label="创建人">
            </el-table-column>
            <el-table-column
                prop="createTime"
                label="创建时间"
                sortable
                width="190"
            >
            </el-table-column>
            <el-table-column label="操作">
                <template slot-scope="scope">
                    <el-button
                        size="mini"
                        type="primary"
                        @click="
                            SettingRole(scope.$index, scope.row, scope.column)
                        "
                        >配置权限</el-button
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

        <el-dialog
            :title="title"
            :visible.sync="dialogVisible"
            :destroy-on-close="true"
        >
            <component
                :is="dialogName"
                ref="form"
                :id="id"
                :key="new Date().getTime()"
            ></component>
            <div slot="footer" class="dialog-footer">
                <el-button @click="dialogVisible = false">取 消</el-button>
                <el-button type="primary" @click="Save()">确 定</el-button>
            </div>
        </el-dialog>
    </div>
</template>

<script>
import axios from "../../utils/axios";
import create from "../Role/create.vue";
import edit from "../Role/edit.vue";
import permission from "../Role/permission.vue";

export default {
    components: {
        create,
        edit,
        permission,
    },
    data() {
        return {
            id: 0,
            dialogVisible: false,
            dialogName: "create",
            title: "添加角色",
            tableData: [],
        };
    },
    methods: {
        addRole() {
            this.dialogVisible = true;
        },
        SaveRole(url,msg) {
            var dialog = this.$refs.form;
            dialog.$refs["ruleForm"].validate((valid) => {
                if (valid) {
                    axios(url, dialog.ruleForm, "post").then((res) => {
                        this.$message({
                            showClose: true,
                            message: msg,
                            type: "success",
                            onClose: () => {
                                this.dialogVisible = false;
                                this.fetch();
                            },
                        });
                    });
                } else {
                    console.log("error submit!!");
                    return false;
                }
            });
        },
        SettingPermission(url,msg) {
            var dialog = this.$refs.form;
            dialog.ruleForm.menuId = dialog.$refs.roleTree.getCheckedKeys();
            axios(url, dialog.ruleForm, "post").then((res) => {
                this.$message({
                    showClose: true,
                    message: msg,
                    type: "success",
                    onClose: () => {
                        this.dialogVisible = false;
                        this.fetch();
                    },
                });
            });
        },
        Save() {
            let url = "",
                msg = "";            

            if (this.dialogName == "create") {
                url = "/role/create";
                msg = "添加角色成功";
                this.SaveRole(url,msg);
            } else if (this.dialogName == "edit") {
                url = "/role/update";
                msg = "编辑角色成功";
                this.SaveRole(url,msg);
            } else if (this.dialogName == "permission") {
                url = "/role/SetPermission";
                msg = "配置权限成功";
                this.SettingPermission(url,msg);
            }
        },
        fetch() {
            axios("/Role/GetList").then((res) => {
                this.tableData = res.data;
            });
        },
        handleEdit(index, row, col) {
            this.dialogVisible = true;
            this.title = "编辑角色";
            this.id = row.roleId;
            this.dialogName = "edit";
        },
        handleDelete(index, row, col) {
            this.$confirm("此操作将永久删除该文件, 是否继续?", "提示", {
                confirmButtonText: "确定",
                cancelButtonText: "取消",
                type: "warning",
            })
                .then(() => {
                    axios(`/role/delete?id=${row.roleId}`).then((res) => {
                        this.$message({
                            type: "success",
                            message: "删除成功!",
                            onClose: () => {
                                this.fetch();
                            },
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
        SettingRole(index, row, col) {
            this.dialogVisible = true;
            this.title = "配置角色";
            this.id = row.roleId;
            this.dialogName = "permission";
        },
    },
    mounted() {
        this.fetch();
    },
};
</script>
