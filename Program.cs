using System;


namespace endtoendencryption
{
     class BANKOFMONEY
    {

        static public int alice_key;

        static public int bob_key;

          static  public double process_bob;

          static public double process_alice;

          static public double process_bob2;

          static public double process_alice2;

          static public double bob_scrambled_key;

          static public double alice_scrambled_key;

          static public double shared_key_alice;

          static public double shared_key_bob;

          static public string compare2;

        static public bool contin = false;



          static public int encrypt(int value)
        {
            if (value == alice_key)
            {
                process_alice = Math.Pow(3, value);
                alice_scrambled_key = process_alice % 17;
                return Convert.ToInt32(alice_scrambled_key);
            }
            else if (value == bob_key)
            {
                process_bob = Math.Pow(3, value);
                bob_scrambled_key = process_bob % 17;
                return Convert.ToInt32(bob_scrambled_key);
            }
            else
            {
                return 0;
            }
        }

         static public int decrypt(int value)
        {
            if(value == alice_scrambled_key)
            {
                process_alice2 = Math.Pow(bob_scrambled_key, alice_key);
                shared_key_alice = process_alice2 % 17;
                return Convert.ToInt32(shared_key_alice);
            }
            if(value == bob_scrambled_key)
            {
                process_bob2 = Math.Pow(alice_scrambled_key, bob_key);
                shared_key_bob = process_bob2 % 17;
                return Convert.ToInt32(shared_key_bob);
            }
            else
            {
                return 0;    
            }
        }

        class MainClass
        {
            
            
            public static void Main(string[] args)
            {
                Console.WriteLine("IN ORDER TO PROCEED WITH TRANSACTION, SHARED KEY MUST BE ENCRYPTED");
                Console.WriteLine("Bob's password (UP TO 30):");
                BANKOFMONEY.bob_key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Alice's password (UP TO 30):");
                BANKOFMONEY.alice_key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("TO CONTINUE TYPE - PROCEED");
                BANKOFMONEY.compare2 = Console.ReadLine();
                if (compare2.Equals("PROCEED") == true)
                {
                    encrypt(BANKOFMONEY.alice_key);
                    encrypt(BANKOFMONEY.bob_key);
                    BANKOFMONEY.contin = true;
                }
                else
                {
                    Console.WriteLine("NOT RECOGNIZED");
                }
                if(contin == true)
                {
                    Console.WriteLine("BOB SCRAMBLED CODE: " + bob_scrambled_key);
                    Console.WriteLine("ALICE SCRAMBLED CODE " + alice_scrambled_key);
                    decrypt(Convert.ToInt32(BANKOFMONEY.bob_scrambled_key));
                    decrypt(Convert.ToInt32(BANKOFMONEY.alice_scrambled_key));
                    Console.WriteLine("BOB RESULT: " + shared_key_bob);
                    Console.WriteLine("ALICE RESULT: " + shared_key_alice);

                }

               







            }
        }
    }
}
