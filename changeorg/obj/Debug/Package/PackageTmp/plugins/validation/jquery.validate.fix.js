jQuery.validator.addMethod("mynumber", function (value, element) {
    return this.optional(element) || /^(\d+|\d+,\d{1,2})$/.test(value);
}, "L�tfen ge�erli bir say� giriniz.");
