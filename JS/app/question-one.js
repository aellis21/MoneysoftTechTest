(function()
{
    const transaction1 = {id: 1, description: 'Woolworths 26Oct', amount: 125.44, category: 'Food and Groceries', transactionType: 'debit', financialAccountID: 3, transactionDate: '2016-06-30' };
    const transaction2 = {id: 2, description: 'Foxtel', amount: 49.95, category: 'Pay TV', transactionType: 'debit', financialAccountID: 4, transactionDate: '2016-07-10' };
    const transaction3 = {id: 3, description: 'Phone/Internet Tfr From xxxxxxxxx8344', amount: 200, category: 'Transfers', transactionType: 'credit', financialAccountID: 4, transactionDate: '2016-07-03'  };
    const transaction4 = {id: 4, description: 'credit card payment', amount: 200, category: 'credit card', transactionType: 'debit', financialAccountID: 3, transactionDate: '2016-07-04' };
    const transaction5 = {id: 4, description: 'credit card payment', amount: 200, category: 'credit card', transactionType: 'debit', financialAccountID: 3, transactionDate: '2016-05-30' };
    const transactionArray = [transaction1, transaction2, transaction3, transaction4, transaction5];

    let transactionProp;
    let descending;

    let sortByProp = function compareFunction(a, b) {

      if(transactionProp !== 'description' && transactionProp !== 'amount' && transactionProp !== 'category') {
          throw 'Sort property not valid';
      }

      let valueA = a[transactionProp];
      let valueB = b[transactionProp];

      if (typeof valueA === 'string'){
          valueA = valueA.toUpperCase();
          valueB = valueB.toUpperCase();
      }

      let sortOrder = 1;

      if (!descending){
        sortOrder = -1;
      }

      if (valueA < valueB) {
        return -1 * sortOrder;
      }
      if (valueA > valueB) {
        return sortOrder;
      }
      return 0;
    };

    console.log(transactionArray);

    //using .slice() to not affect the original array when looking at the data in the console

    transactionProp = 'description';
    descending = false;
    let descriptionSort = transactionArray.slice().sort(sortByProp);
    console.log(descriptionSort);

    transactionProp = 'amount';
    descending = false;
    let amountSort = transactionArray.slice().sort(sortByProp);
    console.log(amountSort);

    transactionProp = 'category';
    descending = true;
    let categorySort = transactionArray.slice().sort(sortByProp);
    console.log(categorySort);

    transactionProp = 'financialAccountID';
    descending = true;
    let failedSort = transactionArray.slice().sort(sortByProp);
    console.log(failedSort);
})();