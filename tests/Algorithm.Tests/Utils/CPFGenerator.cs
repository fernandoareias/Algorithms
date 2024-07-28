using System;

public static class CPFGenerator
{
    public static string GerarCPF()
    {
        Random random = new Random();
        int[] cpf = new int[11];

        // Gerar os primeiros nove dígitos aleatórios
        for (int i = 0; i < 9; i++)
        {
            cpf[i] = random.Next(0, 10);
        }

        // Calcular o primeiro dígito verificador
        cpf[9] = CalcularDigitoVerificador(cpf, 9);

        // Calcular o segundo dígito verificador
        cpf[10] = CalcularDigitoVerificador(cpf, 10);

        // Formatar o CPF com pontos e hífen
        return string.Format("{0}{1}{2}.{3}{4}{5}.{6}{7}{8}-{9}{10}", 
            cpf[0], cpf[1], cpf[2], cpf[3], cpf[4], cpf[5], 
            cpf[6], cpf[7], cpf[8], cpf[9], cpf[10]);
    }

    private static int CalcularDigitoVerificador(int[] cpf, int pos)
    {
        int soma = 0;
        int peso = pos + 1;

        for (int i = 0; i < pos; i++)
        {
            soma += cpf[i] * peso--;
        }

        int resto = soma % 11;

        return (resto < 2) ? 0 : 11 - resto;
    }
}