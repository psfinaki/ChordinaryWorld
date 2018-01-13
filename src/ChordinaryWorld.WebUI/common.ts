function searchIfEnter(e: JQueryKeyEventObject): void {
    const enterKeyCode = 13;
    if (e.keyCode == enterKeyCode) {
        e.data.searcher();
    }
}

function makeUrl(controller: string, query: string) {
    const authority = chooseAuthority();
    return `http://${authority}/api/${controller}?${query}`;
}