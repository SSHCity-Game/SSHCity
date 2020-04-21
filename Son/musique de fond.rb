# rand-seed-ver 33
#
# Coded by Sam Aaron
#
# Video: https://vimeo.com/110416910

use_debug false
load_samples [:bd_haus, :elec_blip, :ambi_lunar_land]




in_thread(name: :bassdrums) do
  use_random_seed 0
  sleep 22
  3.times do
    bd
  end
  sleep 28
  live_loop :bd do
    bd
  end
end

in_thread(name: :drums) do
  use_random_seed 0
  level = -1
  with_fx :echo do |e|
    sleep 2
    drums -1, 0.1
    drums -1, 0.2
    drums -1, 0.4
    drums -1, 0.7
    puts "Part 2"
    puts "Inside the Machine"
    3.times do
      8.times do
        drums level, 0.8
      end
      6.times do
        drums(level)
      end
      
      sleep 1
      level += 1
    end
    sleep 4
    cue :dreams
    8.times do
      drums 1, 1, true
    end
    
    10.times do
      m = choose [shuffle(:within_dreams), :within_dreams, :dreams_within]
      cue m
      drums 2, 1, true
    end
    
    6.times do
      m = choose [shuffle("within") + "_dreams", :within_dreams.shuffle, "dreams_" + shuffle("within")]
      cue m
      drums 2
    end
    
    live_loop :drums do
      8.times do |i|
        drums 1
      end
      
      16.times do |i|
        cue " " * rand_i(32)
        at 1 do
          cue "  " * i
        end
        drums 2
      end
    end
  end
end

in_thread name: :synths do
  use_random_seed 0
  sleep 12
  cue :the_flow_of_logic
  play_synths
end

in_thread do
  use_random_seed 0
  sync :within
  puts "Part 3"
  puts "Reality A"
  sleep 12
  use_synth_defaults phase: 0.5, res: 0.5, cutoff: 80, release: 3.3, wave: 1
  
  2.times do
    [80, 90, 100, 110].each do |cf|
      use_merged_synth_defaults cutoff: cf
      puts "1" * 30
      synth :zawa, note: :e2, phase: 0.25
      synth :zawa, note: :a1
      sleep 3
    end
    4.times do |t|
      binary_celebration(6, 0.5)
      synth :zawa, note: :e2, phase: 0.25, res: rrand(0.8, 0.9), cutoff: [100, 105, 110, 115][t]
      sleep 3
    end
  end
  
  puts 'Part n'
  puts 'The Observer becomes the Observed'
  # Your turn...
end

