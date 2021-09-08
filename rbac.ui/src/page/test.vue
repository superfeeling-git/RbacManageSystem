<template>
  <div>
    <div>
     <!--
      通过v-if和v-else的值，结合paraType的值判断显示哪个表单控件

      显示下拉
      -->
      <template v-if="paraType == 'choices'">
        <select>
          <option v-for="opt in items" :key="opt.id" :value="opt.id">
            {{ opt.name }}
          </option>
        </select>
      </template>
      <!--显示输入-->
      <template v-if="paraType == 'int'">
        <input type="text" :value="age" />
      </template>
    </div>
    <button @click="setValue('choices')">下拉</button>
    <button @click="setValue('int')">输入</button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      paraType: "choices",
      age: 0,
      items: [
        {
          id: 1,
          name: "张三",
        },
        {
          id: 2,
          name: "李四",
        },
      ],
    };
  },
  methods: {
    setValue(parm) {
      this.paraType = parm;
    },
  },
};
</script>