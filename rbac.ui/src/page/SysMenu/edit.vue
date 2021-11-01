<template>
    <div>
        <el-form
            :model="ruleForm"
            ref="ruleForm"
            label-width="120px"
            :rules="rules"
            class="modalForm"
        >
            <el-form-item label="父分类" prop="parentId" ref="parentId">
                <el-cascader
                    v-model="parentId"
                    :options="options"
                    :clearable="true"
                    @change="handleChange"
                    :props="{ checkStrictly: true }"
                    style="width: 300px"
                ></el-cascader>
            </el-form-item>
            <el-form-item label="菜单名称" prop="menuName" ref="menuName">
                <el-input v-model="ruleForm.menuName"></el-input>
            </el-form-item>
            <el-form-item label="菜单排序" prop="orderId">
                <el-input v-model="ruleForm.orderId"></el-input>
            </el-form-item>
            <el-form-item
                label="菜单链接"
                prop="menuLink"
                ref="menuLink"
                v-if="showForm"
            >
                <el-input v-model="ruleForm.menuLink"></el-input>
            </el-form-item>
            <el-form-item label="是否显示" prop="isShow" v-if="showForm">
                <el-switch v-model="ruleForm.isShow"></el-switch>
            </el-form-item>
            <el-form-item v-if="enableSef">
                <el-button type="primary" @click="submitForm('ruleForm')"
                    >立即创建</el-button
                >
                <el-button @click="resetForm('ruleForm')">重置</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
import axios from "../../utils/axios";
import bus from "../../router/bus";
import common from "../../utils/common";

export default {
    name: "editmenu-b",
    data() {
        return {
            enableSef: false,
            parentId: [],
            options: [],
            ruleForm: {
                menuName: "",
                parentId: 0,
                isShow: false,
                menuLink: "",
                orderId: 0
            },
            rules: {
                menuName: [
                    {
                        required: true,
                        message: "请输入菜单名称",
                        trigger: "blur",
                    },
                ],
                orderId: [
                    {
                        required: true,
                        message: "请输入菜单排序",
                        trigger: "blur",
                    },
                ],
            },
        };
    },
    props: {
        pid: {
            type: Array,
        },
    },
    computed: {
        showForm: function () {
            return this.parentId.length > 1 ? true : false;
        },
    },
    methods: {
        submitForm(formName) {
            return new Promise((resolve, reject) => {
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        let _this = this;
                        axios(
                            "/SysMenu/UpdateMenu",
                            this.ruleForm,
                            "post"
                        ).then(
                            (m) => {
                                this.$message({
                                    message: "更新成功",
                                    type: "success",
                                    onClose: function (o) {
                                        //bus.$emit('send',false);
                                        resolve();
                                    },
                                });
                            },
                            (m) => {
                                //console.clear();
                            }
                        );
                    } else {
                        console.log("error submit!!");
                        return false;
                    }
                });
            });
        },
        resetForm(formName) {
            bus.$emit("send", false);
            this.$refs[formName].resetFields();
        },
        handleChange(value) {
            this.ruleForm.parentId = value.slice(-1)[0];
        },
        getmenu(mid) {
            axios(`/SysMenu/QueryMenu?id=${mid}`).then((result) => {
                this.ruleForm = result.data;
            });
        },
    },
    mounted() {
        this.parentId = this.pid;
        this.ruleForm.parentId = this.pid.slice(-1)[0];
        axios("/SysMenu/GetNode").then((res) => {
            this.options = common.clearEmptyChildren(res.data);
        });
    },
};
</script>
