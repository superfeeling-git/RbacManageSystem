<template>
    <div>
        <el-form
            :model="ruleForm"
            :rules="rules"
            ref="ruleForm"
            label-width="100px"
            class="modalForm"
        >
            <el-form-item label="用户名" prop="userName">
                <el-input v-model="ruleForm.userName"></el-input>
            </el-form-item>
            <el-form-item label="密码" prop="password">
                <el-input v-model="ruleForm.password" show-password></el-input>
            </el-form-item>
            <el-form-item label="配置角色" prop="roleId">
                <el-select
                    v-model="roleId"
                    multiple
                    placeholder="请选择"
                    style="width:340px;"
                >
                    <el-option
                        v-for="item in options"
                        :key="item.value"
                        :label="item.label"
                        :value="item.value"
                    >
                    </el-option>
                </el-select>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
import axios from "axios";
export default {
    data() {
        return {
            options: [],
            roleId: [],
            ruleForm: {
                adminId: 0,
                userName: "",
                password: "",
                AdminRole:[]
            },
            rules: {
                userName: [
                    {
                        required: true,
                        message: "请输入用户名",
                        trigger: "blur",
                    },
                ],
                password: [
                    {
                        required: true,
                        message: "请输入密码",
                        trigger: "blur",
                    },
                ]
            },
        };
    },
    methods: {
        resetForm(formName) {
            this.$refs[formName].resetFields();
        },
    },
    mounted() {
        axios("/Role/GetList").then((res) => {
            this.options = res.data.map((v) => {                
                let json = {};
                json.value = v.roleId;
                json.label = v.roleName;
                return json;
            });
        });
    },
};
</script>