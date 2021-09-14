<template>
  <div>
    <el-form
      :model="ruleForm"
      ref="ruleForm"
      label-width="100px"
      :rules="rules"
      class="ruleForm"
    >
      <el-form-item label="菜单名称" prop="MenuName">
        <el-input v-model="ruleForm.MenuName"></el-input>
      </el-form-item>

      <el-form-item>
        <el-button type="primary" @click="submitForm('ruleForm')"
          >立即创建</el-button
        >
        <el-button @click="resetForm('ruleForm')">重置</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import config from '../../utils/config'


export default {
  data() {
    return {
      ruleForm: {
        MenuName: "",
      },
        rules: {
          MenuName: [
            { required: true, message: '请输入菜单名称', trigger: 'blur' }
          ]
        },
    };
  },
  methods: {
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          config.axios.post('/api/SysMenu/CreateRootMenu',this.ruleForm).then(m=>{
              //console.log(m);
          });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
  },
};
</script>
