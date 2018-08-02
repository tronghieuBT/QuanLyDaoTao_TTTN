function SaveLocalCache(name, data) {
    if (window.localStorage) {
        window.localStorage[name] = JSON.stringify(dataJson);
    }
}
function GetLocalCache(name) {
    if (window.localStorage) {
        if (window.localStorage[name]) {
            return JSON.parse(window.localStorage[name]);
        }
    }
    return '';
}