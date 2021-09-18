<template>
  <div>
    <el-form
      :model="ruleForm"
      ref="ruleForm"
      label-width="100px"
      :rules="rules"
      class="ruleForm"
    >
      <el-form-item label="菜单名称" prop="menuName" ref="menuName">
        <el-input v-model="ruleForm.menuName"></el-input>
      </el-form-item>

      <el-form-item v-if="enableSelf">
        <el-button type="primary" @click="submitForm('ruleForm')"
          >立即创建</el-button
        >
        <el-button @click="resetForm('ruleForm')">重置</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
import config from "../../utils/config";
import bus from "../../router/bus";

export default {
  name: "editmenu-b",
  data() {
    return {
      enableSelf: false,
      ruleForm: {
        menuID: 32,
        menuName: "",
      },
      rules: {
        menuName: [
          { required: true, message: "请输入菜单名称", trigger: "blur" },
        ],
      },
    };
  },
  methods: {
    submitForm(formName) {
      return new Promise((resolve, reject) => {
        this.$refs[formName].validate((valid) => {
          if (valid) {
            let _this = this;
            config.axios.post("/SysMenu/UpdateMenu", this.ruleForm).then(
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
    getmenu(mid) {
      config.axios
        .get("/SysMenu/QueryMenu", {
          params: {
            id: mid,
          },
        })
        .then((result) => {
          //console.log(result);
          this.ruleForm = result.data;
        });
    },
  }
};
</script>
