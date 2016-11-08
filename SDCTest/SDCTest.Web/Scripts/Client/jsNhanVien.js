$(document)
    .ready(function() {
        $("#TinhThanh")
            .change(function() {
                $("#Quan").empty();
                $.ajax({
                    type: 'POST',
                    url: '/NhanVien/GetQuan',

                    dataType: 'json',

                    data: { id: $("#TinhThanh").val() },

                    success: function(quans) {


                        $.each(quans,
                            function(i, quan) {
                                $("#Quan")
                                    .append('<option value="' +
                                        quan.Value +
                                        '">' +
                                        quan.Text +
                                        '</option>');

                            });
                    },
                    error: function(ex) {
                        alert('Lỗi.' + ex);
                    }
                });
                return false;
            });

        $("#NgaySinh").datepicker({ dateFormat: 'dd/mm/yy' });

        $('#form-nhanvien-insert')
            .bootstrapValidator({
                message: 'This value is not valid',
                feedbackIcons: {
                    valid: 'icon icon-ok',
                    invalid: 'icon icon-remove',
                    validating: 'icon icon-refresh'
                },
                fields: {
                    HoTen: {
                        validators: {
                            notEmpty: {
                                message: 'Họ Tên không được để trống'
                            }
                        }
                    },
                    SDT: {
                        validators: {
                            notEmpty: {
                                message: 'SĐT không được để trống'
                            },
                            regexp: {
                                message: 'SĐT không đúng',
                                regexp: /^[0-9\s\-()+\.]+$/
                            }
                        }
                    },
                    Email: {
                        validators: {
                            notEmpty: {
                                message: 'Email không được để trống'
                            },
                            emailAddress: {
                                message: 'Email không đúng định dạng'
                            }
                        }
                    }
                }
            });

        $('#form-nhanvien-update')
            .bootstrapValidator({
                message: 'This value is not valid',
                feedbackIcons: {
                    valid: 'icon icon-ok',
                    invalid: 'icon icon-remove',
                    validating: 'icon icon-refresh'
                },
                fields: {
                    HoTen: {
                        validators: {
                            notEmpty: {
                                message: 'Họ Tên không được để trống'
                            }
                        }
                    },
                    SDT: {
                        validators: {
                            notEmpty: {
                                message: 'SĐT không được để trống'
                            },
                            regexp: {
                                message: 'SĐT không đúng',
                                regexp: /^[0-9\s\-()+\.]+$/
                            }
                        }
                    },
                    Email: {
                        validators: {
                            notEmpty: {
                                message: 'Email không được để trống'
                            },
                            emailAddress: {
                                message: 'Email không đúng định dạng'
                            }
                        }
                    }
                }
            });
    });

