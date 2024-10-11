$(document).ready(function () {
    // Event handler for adding new guests
    $(document).off('click', '#add-guest');
    $("#add-guest").on("click", function () {
        const newGuest = $("#additional-guests-container > input").first().clone();
        newGuest.val('');
        $("#additional-guests-container").append(newGuest);
    });

    // Validate CPF/CNPJ and Email
    $(document).off('click', '.create-reservation');
    $('#create-reservation').on('click', function (event) {
        event.preventDefault();
        let isValid = true;

        const cpfCnpj = $('#cpfCnpj');
        const email = $('#email');

        // CPF/CNPJ validation
        if (!validateCpfCnpj(cpfCnpj.val())) {
            cpfCnpj.siblings('span.text-danger').text('CPF/CNPJ inválido.').removeClass('d-none');
            isValid = false;
        } else {
            cpfCnpj.siblings('span.text-danger').addClass('d-none');
        }

        // Email validation
        if (!validateEmail(email.val())) {
            email.siblings('span.text-danger').text('E-mail inválido.').removeClass('d-none');
            isValid = false;
        } else {
            email.siblings('span.text-danger').addClass('d-none');
        }

        if (isValid) {
            let additionalGuests = [];
            $('#additional-guests-container input[name="AdditionalGuests"]').each(function () {
                additionalGuests.push($(this).val());
            });
            let formData = {
                CpfCnpj: cleanCpfCnpj(cpfCnpj.val()),
                Name: $('#name').val(),
                Email: email.val(),
                Phone: $('#phone').val(),
                ZipCode: $('#zip-code').val(),
                Address: $('#address').val(),
                AddressNumber: $('#address-number').val(),
                Complement: $('#complement').val(),
                Neighborhood: $('#neighborhood').val(),
                City: $('#city').val(),
                State: $('#state').val(),
                StartDate: $('#start-date').val(),
                EndDate: $('#end-date').val(),
                Observations: $('#observations').val(),
            };

            $.ajax({
                url: '/Home/Create',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(formData),
                success: function (result) {
                    $('#create-modal').modal('hide');
                },
                error: function (xhr, status, error) {
                    alert('Error creating reservation: ' + xhr.responseText);
                }
            });
        }
    });

    // CPF/CNPJ validation
    function validateCpfCnpj(value) {
        value = cleanCpfCnpj(value);
        // CPF validation regex (11 digits)
        const cpfRegex = /^\d{11}$/;
        // CNPJ validation regex (14 digits)
        const cnpjRegex = /^\d{14}$/;
        if (value.length === 11) {
            return cpfRegex.test(value);
        } else if (value.length === 14) {
            return cnpjRegex.test(value);
        } else {
            return false;
        }
    }


    // Email validation
    function validateEmail(value) {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(value);
    }

    function cleanCpfCnpj(value) {
        return value.replace(/\D/g, ''); // Removes all non-digit characters
    }
});