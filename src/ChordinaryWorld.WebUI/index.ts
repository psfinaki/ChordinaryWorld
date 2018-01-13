/// <reference path="helper.ts" />

module Index {
    function search(): void {
        $('#result').addClass("invisible");
        $('#progress').removeClass("invisible");

        const artist = $('#artist').val();
        const title = $('#title').val();

        const query = makeQueryHarmonies(artist, title);
        const url = makeUrl("harmonies", query);
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
        const count = 6;

        const query = makeQueryTop(count);
        const url = makeUrl("top", query);
        $.get(url)
            .done((response: [string, string, number][]) => {
                $('#top').removeClass("invisible");
                $.each(response, (key, item: any) => {
                    function formatTopLine(item: [string, string, number]) {
                        return `${item[0]} - ${item[1]} (${item[2]})`;
                    }

                    // for some reason, it does not work directly
                    const itemDTO: [string, string, number] = [item.item1, item.item2, item.item3];
                    $('<li>', { text: formatTopLine(itemDTO) }).appendTo($('#topList'));
                });
            });
    }

    $(() => {
        $('#search').click(search);

        // this is why keyup:
        // https://stackoverflow.com/questions/155188/trigger-a-button-click-with-javascript-on-the-enter-key-in-a-text-box#comment13009121_155263
        $('#artist').keyup({ searcher: search }, searchIfEnter);
        $('#title').keyup({ searcher: search }, searchIfEnter);

        $('#artist').focus();

        fillTop();
    });
}