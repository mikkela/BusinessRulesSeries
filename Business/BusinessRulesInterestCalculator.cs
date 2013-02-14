namespace Business
{
    public class BusinessRulesInterestCalculator
    {
        private enum ApplicantCategory
        {
            UnderAged,
            Young,
            MiddleAged,
            Old
        }

        private ApplicantCategory CategorizeApplicant(int age)
        {
            if (age < 18)
                return ApplicantCategory.UnderAged;

            if (age <= 25)
                return ApplicantCategory.Young;

            if (age <= 65)
                return ApplicantCategory.MiddleAged;

            return ApplicantCategory.Old;
        }

        public int? CalculateInterestRate(int age)
        {
            switch (CategorizeApplicant(age))
            {
                    case ApplicantCategory.UnderAged:
                    return null;
                    case ApplicantCategory.Young:
                    return 25;
                    case ApplicantCategory.MiddleAged:
                    return 15;
                    case ApplicantCategory.Old:
                    return 20;
            }
            return null;
        }

        public string GetReason(int age)
        {
            switch (CategorizeApplicant(age))
            {
                case ApplicantCategory.UnderAged:
                    return "Because you are too young";
                case ApplicantCategory.Young:
                    return "Because you will party before you pay";
                case ApplicantCategory.MiddleAged:
                    return "Because you got family - we get security";
                case ApplicantCategory.Old:
                    return "Because you are old";
            }
            return null;
        }
    }
}