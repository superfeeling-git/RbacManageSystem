<template>
    <div>
        <el-form :inline="true" :model="formInline" class="demo-form-inline">
            <el-form-item label="用户名">
                <el-input
                    v-model="formInline.keywords"
                    placeholder="用户名"
                ></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="onSubmit">查询</el-button>
                <el-button
                    type="primary"
                    class="addbtn"
                    @click="addadmin"
                    size="medium"
                    >添加管理员</el-button
                >
            </el-form-item>
        </el-form>

        <el-table :data="tableData" stripe style="width: 100%" border>
            <el-table-column prop="adminId" label="ID"></el-table-column>
            <el-table-column prop="userName" label="用户名"></el-table-column>
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

        <el-pagination
            background
            layout="prev, pager, next"
            :total="formInline.total"
            :page-size="formInline.pagesize"
            @current-change="handleCurrentChange"
            class="page"
        >
        </el-pagination>
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
import create from "../Admin/create";
import edit from "../Admin/edit.vue";
import role from "../Admin/Role.vue";

export default {
    components: {
        create,
        edit,
        role,
    },
    data() {
        return {
            id: 0,
            dialogVisible: false,
            dialogName: "create",
            title: "添加管理员",
            tableData: [],
            formInline: {
                total: 0,
                pageindex: 1,
                pagesize: 2,
                keywords: "",
            },
        };
    },
    methods: {
        handleCurrentChange(val) {
            this.formInline.pageindex = val;
            this.fetch(this.formInline);
        },
        onSubmit() {
            this.formInline.pageindex = 1;
            this.fetch(this.formInline);
        },
        addadmin() {
            this.dialogVisible = true;
        },
        Saveadmin(url, msg) {
            var dialog = this.$refs.form;
            //用多选值初始化数据
            dialog.ruleForm.adminRole = dialog.roleId.map((v) => {
                let json = {};
                json.adminId = dialog.ruleForm.adminId, 
                json.roleId = v;
                return json;
            });

            dialog.$refs["ruleForm"].validate((valid) => {
                if (valid) {
                    axios(url, dialog.ruleForm, "post").then((res) => {
                        let type = "success";
                        if (res.data.code > 0) {
                            type = "warning";
                            msg = res.data.msg;
                        }
                        this.$message({
                            showClose: true,
                            message: msg,
                            type: type,
                            onClose: () => {
                                this.dialogVisible = false;
                                this.fetch(this.formInline);
                            },
                        });
                    });
                } else {
                    console.log("error submit!!");
                    return false;
                }
            });
        },
        Save() {
            let url = "",
                msg = "";

            if (this.dialogName == "create") {
                url = "/admin/create";
                msg = "添加管理员成功";
                this.Saveadmin(url, msg);
            } else if (this.dialogName == "edit") {
                url = "/admin/update";
                msg = "编辑管理员成功";
                this.Saveadmin(url, msg);
            } else if (this.dialogName == "Role") {
                url = "/admin/SetRole";
                msg = "配置角色成功";
                this.SettingRole(url, msg);
            }
        },
        fetch(params) {
            axios("/admin/PageList", undefined, undefined, params).then(
                (res) => {
                    this.formInline.total = res.data.item1;
                    this.tableData = res.data.item2;
                }
            );
        },
        handleEdit(index, row, col) {
            this.dialogVisible = true;
            this.title = "编辑管理员";
            this.id = row.adminId;
            this.dialogName = "edit";
        },
        handleDelete(index, row, col) {
            this.$confirm("此操作将永久删除该文件, 是否继续?", "提示", {
                confirmButtonText: "确定",
                cancelButtonText: "取消",
                type: "warning",
            })
                .then(() => {
                    axios(`/admin/delete?id=${row.adminId}`).then((res) => {
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
    },
    mounted() {
        this.fetch(this.formInline);
    },
};
</script>