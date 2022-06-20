<template>
    <div>
        <el-form :inline="true" :model="formInline" class="demo-form-inline">
            <el-form-item label="用户名">
                <el-input
                    v-model="formInline.user"
                    placeholder="审批人"
                ></el-input>
            </el-form-item>
            <el-form-item label="用户卡类型">
                <el-select v-model="formInline.region" placeholder="用户卡类型">
                    <el-option label="区域一" value="shanghai"></el-option>
                    <el-option label="区域二" value="beijing"></el-option>
                </el-select>
            </el-form-item>
            <el-form-item label="用户卡级别">
                <el-select v-model="formInline.region" placeholder="用户卡级别">
                    <el-option label="区域一" value="shanghai"></el-option>
                    <el-option label="区域二" value="beijing"></el-option>
                </el-select>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="onSubmit">查询</el-button>
                <el-button type="warning" @click="onSubmit">批量删除</el-button>
            </el-form-item>
        </el-form>

        <el-table :data="tableData" border style="width: 100%">
            <el-table-column type="selection" width="55"> </el-table-column>
            <el-table-column prop="id" label="卡ID" width="80">
            </el-table-column>
            <el-table-column prop="cardNum" label="卡号" width="180">
            </el-table-column>
            <el-table-column prop="name" label="会员姓名"> </el-table-column>
            <el-table-column prop="carType" label="卡类型"> </el-table-column>
            <el-table-column prop="carLevel" label="卡级别"> </el-table-column>
            <el-table-column prop="date" label="注册日期"> </el-table-column>
            <el-table-column  label="卡状态">
                <template slot-scope="scope">
                    <span :class="{'red': !scope.row.carStatus}">
                        {{scope.row.carStatus?"正常":"锁定"}}
                    </span>
                </template>
            </el-table-column>
            <el-table-column label="操作">
                <template slot-scope="scope">
                    <el-button
                        size="mini"
                        :type="scope.row.carStatus?'success':'danger'"
                        @click="handleEdit(scope.$index, scope.row)"
                        >
                        {{scope.row.carStatus?"锁定":"解锁"}}
                        </el-button
                    >
                    <el-button
                        size="mini"
                        type="primary"
                        @click="handleDelete(scope.$index, scope.row)"
                        >删除</el-button
                    >
                </template>
            </el-table-column>
        </el-table>

        <el-pagination background layout="prev, pager, next" :total="1000" class="page">
        </el-pagination>
    </div>
</template>

<style>
.red{
    color: red;
}
.page{
    text-align: center;
}
</style>

<script>
export default {
    data() {
        return {
            formInline: {
                user: "",
                region: "",
            },
            tableData: [
                {
                    date: "2016-05-02",
                    name: "王小虎",
                    id: 1,
                    cardNum: "2934792349",
                    carType: "实体卡",
                    carLevel: "白金会员",
                    carStatus: false,
                },
                {
                    date: "2016-05-02",
                    name: "张小三",
                    id: 1,
                    cardNum: "2934792349",
                    carType: "电子卡",
                    carLevel: "黄金会员",
                    carStatus: false,
                },
                {
                    date: "2016-05-02",
                    name: "王小虎",
                    id: 1,
                    cardNum: "2934792349",
                    carType: "实体卡",
                    carLevel: "白金会员",
                    carStatus: false,
                },
                {
                    date: "2016-05-02",
                    name: "王小虎",
                    id: 1,
                    cardNum: "2934792349",
                    carType: "实体卡",
                    carLevel: "白金会员",
                    carStatus: true,
                },
                {
                    date: "2016-05-02",
                    name: "王小虎",
                    id: 1,
                    cardNum: "2934792349",
                    carType: "实体卡",
                    carLevel: "白金会员",
                    carStatus: true,
                },
                {
                    date: "2016-05-02",
                    name: "王小虎",
                    id: 1,
                    cardNum: "2934792349",
                    carType: "实体卡",
                    carLevel: "白金会员",
                    carStatus: true,
                },
                {
                    date: "2016-05-02",
                    name: "王小虎",
                    id: 1,
                    cardNum: "2934792349",
                    carType: "实体卡",
                    carLevel: "白金会员",
                    carStatus: true,
                },
            ],
        };
    },
    methods: {
        onSubmit() {
            console.log("submit!");
        },
    },
};
</script>