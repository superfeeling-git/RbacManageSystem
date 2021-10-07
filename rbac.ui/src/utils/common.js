var clearEmptyChildren = (data) => {
    var reg = new RegExp('\\,"children":\\[]', 'g');
    return JSON.parse(JSON.stringify(data).replace(reg, ''));
};

export default {
    clearEmptyChildren
}