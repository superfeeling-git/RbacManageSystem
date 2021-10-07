<template>
    <div>
        <el-form
            :model="ruleForm"
            :rules="rules"
            ref="ruleForm"
            label-width="100px"
            class="modalForm"
        >
            <el-form-item label="角色名称" prop="roleName">
                <el-input v-model="ruleForm.roleName"></el-input>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
import axios from "axios";
export default {
    data() {
        return {
            ruleForm: {
                roleId: 0,
                roleName: "",
            },
            rules: {
                roleName: [
                    {
                        required: true,
                        message: "请输入活动名称",
                        trigger: "blur",
                    },
                ],
            },
        };
    },
    props: {
        id: {
            type: Number,
        },
    },
    methods: {
        resetForm(formName) {
            this.$refs[formName].resetFields();
        },
    },
    mounted() {
        axios(`/role/find?id=${this.id}`).then((res) => {
            this.ruleForm = res.data;
        });
    },
};
</script>