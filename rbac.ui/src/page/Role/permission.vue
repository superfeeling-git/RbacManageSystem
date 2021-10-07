<template>
    <div>
        <el-tree
            :data="data"
            show-checkbox
            node-key="value"
            ref="roleTree"
            :default-expanded-keys="checkedKeys"
            :default-checked-keys="checkedKeys"
            :props="defaultProps"
            :default-expand-all="expandAll"
        >
        </el-tree>
    </div>
</template>

<script>
import axios from '../../utils/axios'
import common from '../../utils/common'

  export default {
    data() {
      return {
        data: [],
        checkedKeys:[],
        defaultProps: {
          children: 'children',
          label: 'label'
        },
        ruleForm:{
            roleId:0,
            menuId:[]
        }
      };
    },
    computed:{
        expandAll:function(){
            return this.checkedKeys.length > 0 ? false : true;
        }
    },
    props: {
        id: {
            type: Number,
        },
    },
    async mounted() {
        this.ruleForm.roleId = this.id;

        await axios("/SysMenu/GetNode").then((res) => {            
            this.data = common.clearEmptyChildren(res.data);
        });
        
        await axios(`/Role/GetPermission?id=${this.id}`).then(res=>{
            this.checkedKeys = res.data;
        });
    },
  };
</script>