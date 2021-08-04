(function () {
    let curIndex = 1;
    $('.multi-field-wrapper').each(function () {
        let $wrapper = $('.multi-fields', this);
        const cleanCopy = $('.multi-field:first-child', $wrapper).clone(true, true);
        $('.add-field', $(this)).click(function (e) {
            let copied = cleanCopy.clone(true, true);
            let arr = copied.find(".track-input").val('');
            let hiddenInputs = copied.find('.hidIndex');
            for (let i = 0; i < arr.length; i++) {
                let name;
                name = arr.eq(i).attr('name');
                name = name.replace(/\[[0-9]+\]/g, '[' + curIndex + ']');
                arr.eq(i).attr('name', name);
                hiddenInputs.eq(i).attr('value', curIndex);
            }
            copied.appendTo($wrapper);
            curIndex++;
        });

        $($wrapper).on('click', '.multi-field .remove-field', function () {
            if ($('.multi-field', $wrapper).length > 1)
                $(this).parent('.multi-field').remove();
        });
    });
})();
