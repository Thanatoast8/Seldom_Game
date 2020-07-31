VAR potato = false
VAR leaf = false
VAR oldManCoin = 50

EXTERNAL removePotato()
EXTERNAL removeLeaf()
EXTERNAL addCoinToPlayer(coin)

Greetings young man! How goes thee?

*[Good, How about you?]I'm doing alright myself. How are you sir?
    Oh, I'm not doing so well. I've been wandering the forest as I normally do and my joints started hurting. I must get going or dinner is going to get cold.
    **[It's the middle of the day]Are you alright? It's midday right now and there is not a cottage in sight.
        It's me joints sonny. They just aren't moving like they used to. If only there was something that could help me.
        ***[Buy my stuff.]If it's your joints I may have a remedy right here. It's pretty rare, but I'm willing to cut you a deal.
            ->sellItems.startTransaction
    **[I think I can help]I see. Do you want some help?
        Oh. No need to worry about me. Worry about yourself. How did you even end up here? This part of the forest is closed off from the outside.
        ***Wait what?
            You heard me. Now back off before you become my next and possibly final meal.
            ->failedInteraction

*[Buy this stuff.]I see that you do not feel like you did in your prime. I have the perfect rememdy for this. 
    Eh, What else am I supposed to do?
    ->sellItems.startTransaction

*[I don't have time for this old man.] I'm very buisy right now, I need to get going but can you do me a quick favour?
    I do think you're being quite rude. What could you be doing right now that's so important that you cant help an old man in trouble?
    **[No time, buy something]I do not have a lot of time left on this planet. You have to buy this thing.
        No. I don't think I will.
        ->END
    **[I'm running from my wife]I'm running away from my wife and am in desperate need of coin. Please buy something.
        Ah. I see. I'm hiding from my wife right now. I guess I can help you out, just don't tell my wife.
        ->sellItems.startTransaction

*[Quit]I need to get going now. Goodbye.
    ->END

=== sellItems ===

=startTransaction
Let's see here...

+   {potato && oldManCoin > 0}    [I have a Potato] -> sellPotato
+   {leaf && oldManCoin > 0}      [I have a Leaf] -> sellLeaf
+   {oldManCoin > 0}              [No items to sell]Oh! I dont have anything right now. I'll be back in a sec!
        ->END
+   {oldManCoin == 0}              Oh deary me. I don't have anything to offer to you young chap. you best get going.
    Pleasure doing buissness with you sir. I hope you get better soon.
    -> END

= sellPotato
    Here I hold a mystical stone of life. It bears many healing properties which must be activated.
    How does it work?
    
    *[Plant it]Legend has it that if you place this rock in a hole in the ground it will take root and using the power of the sun, create a herb with all of it's properties. Once purple flowers start to bloom, you should be able to dig it up and find new stones. The plant itself will heal you through it's magic aura. And theese new stones will also function just like the original.
        Sounds great! <> ->succsesfulInteraction(30, potato)
                
    *[Cook it]You should be able to introduce this stone into your meal. While it is a rock, it can be cut an peeled to show it's raw potential. Add it to your stew when you cook it and it's healing properties will bleed into your food.
        I'm afraid that won't do. If my wife find something like this in our stew she will make me sleep outside for a week. I just can't take that risk. I'm sorry sonny but I can't buy that.
        ->failedInteraction
        
    *[Brew it]Peel the outer husk off of it and place it in a barrel with some yeast or something.
        Like mead?
        Yes. Just like mead.
        So if I make this stone mead it will help all of my joints?
        Or the legend goes.
        I see what you're doing. You just want to poison me! You should know that stones have been placed in mead to poison it. If my joints didn't hurt so much right now you'd be in a world of pain sonny boy.
        ->failedInteraction
    
    =sellLeaf
    I have a rare herb with me from my travels. It grows only on the highest of mountains far in the north.
    There are mountains in the north?
    
    *[Nother than north]Yes, if you travel very far.
        Oh, my mistake. Continue.
        
        **[Brew the leaf]When brewed into a hot tea this herb can cure any of your stiff joints and you will wake up feeling as limber as that one really limber person.
            Who?
            You know. That guy.
            What guy? We're the only ones here sonny.
            ->failedInteraction
            
        **[Eat the leaf]When consumed, this leaf will stop all joint pain for a week. You should be able to get home after this.
            That sounds absolutely smashing <> -> succsesfulInteraction(20, leaf)
        
    *[I meant south]Did I say north? I meant south. The peaks of mountains in the south.
        I don't belive there are mountains in the south either. As a matter of fact, there aren't mountains anywere in this land sonny.
        ->failedInteraction


=== failedInteraction ===
Errrrrrr...
+ [Run]LOOK! A WORKING OPTIONS MENU!
        Where?
        ->END
+ [Try again]Let me check what else I have.
        It best be good
        ->sellItems.startTransaction
        
        
=== succsesfulInteraction(price, item) ===

{
    - oldManCoin >= price:
        I can offer you {price} for that. How does that sound?
        *[Accept]That's a little low but it's ok. I'll take that.
            I guess i'll have to go and get to work now. Thank you.
            ~oldManCoin = oldManCoin - price
            ~addCoinToPlayer(price)
            {
                - item == potato:
                    {removePotato()}
                - item == leaf:
                    {removeLeaf()}
            }
            ->END
        *{oldManCoin > price}[Haggle]You see, theese are a little hard to come by, could you raise that a little?
            ->succsesfulInteraction(price + oldManCoin/2-price/2, item)
        *[Decline]I'm sorry but i can't take you up on that offer.
            That's a real shame. I was really looking forward to seeing my wife again.
            -> failedInteraction
    - else:
     Sorry sonny boy but i'm affraid I cannot afford that. 
     ->failedInteraction
}
