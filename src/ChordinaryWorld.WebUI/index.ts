/// <reference path="helper.ts" />

function search(): void {
    $('#result').addClass("invisible");
    $('#progress').removeClass("invisible");

    const artist = $('#artist').val();
    const title = $('#title').val();

    const url = makeUrlHarmonies(artist, title);
    $.get(url)
        .done((response: number) => {
            const message = formatSuccess(response);
            $('#result').text(message);
        })
        .fail((response: JQueryXHR) => {
            const message = formatFailure(response.status);
            $('#result').text(message);
        })
        .always(() => {
            $('#progress').addClass("invisible");
            $('#result').removeClass("invisible");
        });
}

function fillTop() {
    const url = makeUrlTop();
    $.get(url)
        .done((response: [string, string, number][]) => {
            $('#top').removeClass("invisible");
            $.each(response, (key, item: any) => {
                // for some reason, it does not work directly
                const itemDTO: [string, string, number] = [item.item1, item.item2, item.item3];
                $('<li>', { text: formatTopLine(itemDTO) }).appendTo($('#topList'));
            });
        });
}

function searchIfEnter(e: JQueryKeyEventObject): void {
    const enterKeyCode = 13;
    if (e.keyCode == enterKeyCode) {
        search();
    }
}

$(() => {
    $('#search').click(search);

    // this is why keyup:
    // https://stackoverflow.com/questions/155188/trigger-a-button-click-with-javascript-on-the-enter-key-in-a-text-box#comment13009121_155263
    $('#artist').keyup(searchIfEnter);
    $('#title').keyup(searchIfEnter);

    $('#artist').focus();

    fillTop();
});