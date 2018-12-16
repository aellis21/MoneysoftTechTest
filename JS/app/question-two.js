class FinancialAccount{
    constructor(userID, name, balance, transactions){
        this.userID = userID;
        this.name = name;
        this.balance = balance;
        this.transactions = transactions;
    }

    static getBalanceAtDate(date){
        let datedBalance = this.balance;
        this.transactions.forEach(function (element){
            if (element.date > date){
                datedBalance = datedBalance - element.amount;
            }
        });

        return datedBalance;
    }

}