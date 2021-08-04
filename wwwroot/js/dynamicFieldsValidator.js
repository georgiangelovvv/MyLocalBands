
$('#submit-button').click(validationEvent);

function validationEvent() {
    validateForm();
}

function validateForm() {

    $('#my-form').validate({
        rules: {
            'Name': {
                required: true,
                maxlength: 50,
            },
            'ReleaseDate': {
                required: true
            },
            'Artwork': {
                required: true
            },
            'Lineup': {
                required: true,
                minlength: 15,
                maxlength: 500
            }
        },
        messages: {
            'Name': {
                required: 'Name is required.',
                maxlength: 'Max length is 50 characters.'
            },
            'ReleaseDate': {
                required: 'Release date is required.'
            },
            'Artwork': {
                required: 'Artwork is required.'
            },
            'Lineup': {
                required: 'Lineup is required.',
                minlength: 'Min length is 15 characters.',
                maxlength: 'Max length is 500 characters.'
            }
        }
    });

    $('.track-number').each(function () {
        $(this).rules('add', {
            required: true,
            range: [1, 99],
            messages: {
                required: 'Fill in.',
                range: '01-99'
            }
        });
    });

    $('.track-title').each(function () {
        $(this).rules('add', {
            required: true,
            maxlength: 50,
            messages: {
                required: 'Song title is required.',
                maxlength: 'Max length is 50 characters.'
            }
        });
    });

    $('.track-duration').each(function () {
        $(this).rules('add', {
            required: true,
            range: [0, 59],
            messages: {
                required: 'Fill in.',
                range: '00-59'
            }
        });
    });

    $('.youtube-link').each(function () {
        $(this).rules('add', {
            maxlength: 70,
            messages: {
                maxlength: 'Max length is 70 characters.'
            }
        });
    });
}