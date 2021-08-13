(function ($) {
    var _orderService = abp.services.app.order;
    _$modal = $('#Modal');
    _$table = $('#OrdersTable');

    var _$ordersTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#OrdersSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _orderService.getAllOrders(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$ordersTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'productName',
                sortable: false
            },
            {
                targets: 2,
                data: 'categoryName',
                sortable: false
            },
            {
                targets: 3,
                data: 'customerName',
                sortable: false
            },
            {
                targets: 4,
                data: 'orderDate',
                sortable: false,
                render: function (data) {
                    return moment(data).format('L')
                }
            },
            {
                targets: 5,
                data: 'amount',
                sortable: false
            }
        ]
    });

    $(document).on('click', '#CreateOrderBtn', function () {
        abp.ajax({
            url: abp.appPath + 'Orders/CreateModal',
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                _$modal.modal('toggle');
                $('#Modal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', '.save-button', function (e) {
        e.preventDefault();
        save();
    });

    $('.btn-search').on('click', (e) => {
        _$ordersTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$ordersTable.ajax.reload();
            return false;
        }
    });

    function save() {
        _$form = _$modal.find('form');
        if (!_$form.valid()) {
            return;
        }
        var order = _$form.serializeFormToObject();
        abp.ui.setBusy(_$modal);
        _orderService.create(order).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info('SavedSuccessfully');
            _$ordersTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }
})(jQuery);