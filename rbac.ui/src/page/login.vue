<template>
  <div class="login">
    <el-card class="box-card">
      <div slot="header" class="clearfix">
        <span>卡片名称</span>
        <el-button style="float: right; padding: 3px 0" type="text"
          >操作按钮
        </el-button>
      </div>

      <el-form
        :model="ruleForm"
        :rules="rules"
        ref="ruleForm"
        label-width="100px"
        class="demo-ruleForm"
      >
        <el-form-item label="用户名" prop="UserName">
          <el-input v-model="ruleForm.UserName"></el-input>
        </el-form-item>
        <el-form-item label="密码" prop="Password">
          <el-input v-model="ruleForm.Password"></el-input>
        </el-form-item>
        <el-form-item label="验证码" prop="ValidateCode">
           <el-col :span="16">
             <el-input v-model="ruleForm.ValidateCode"></el-input>
           </el-col>
           <el-col :span="8">
             <img :src="ValidateCodeSrc">
           </el-col>          
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="submitForm('ruleForm')"
            >立即创建</el-button
          >
          <el-button @click="resetForm('ruleForm')">重置</el-button>
        </el-form-item>
      </el-form>
    </el-card>
  </div>
</template>

<script>
import config from '../utils/config'

export default {
  data() {
    return {
      ValidateCodeSrc:`${config.baseUrl}/Account/ValidateCode`,
      ruleForm: {
          UserName: '',
          Password: '',
          ValidateCode: ''
        },
        rules: {
          UserName: [
            { required: true, message: '请输入用户名', trigger: 'blur' },
            { min: 3, max: 5, message: '长度在 3 到 5 个字符', trigger: 'blur' }
          ],
          Password: [
            { required: true, message: '请输入密码', trigger: 'change' }
          ],
          ValidateCode: [
            { required: true, message: '请输入验证码', trigger: 'change' }
          ]
        }
    }
  },
  methods: {
    submitForm(formName) {
        this.$refs[formName].validate((valid) => {
          if (valid) {
            var obj = this;
            config.axios.post(`/Account/Login`,
            this.ruleForm,
            {withCredentials: true}).then(m=>{
              if(m.data.code > 0){
                this.$message({
                  message: m.data.msg,
                  type: 'warning'
                });
              }
              else{
                localStorage.setItem("token",m.data.token);
                config.axios.defaults.headers.common['Authorization'] = `bearer ${m.data.token}`;
                this.$router.push("home");
                //window.location.href = "#/home";
              }              
            });
          } else {
            
            return false;
          }
        });
      },
      resetForm(formName) {
        this.$refs[formName].resetFields();
      }
  },
  mounted() {
    console.log('login')
  },
};
</script>

<style scoped>
.login {
  width: 100%;
  height: 100%;
  overflow: hidden;
  background: rgb(218, 168, 168);
}

.box-card {
  width: 480px;
  margin: 0 auto;
  margin-top: 14em;
}
</style>